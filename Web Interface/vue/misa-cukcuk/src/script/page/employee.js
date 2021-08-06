$(document).ready(function () {
    loadData();
    initEvents();
})

/**
 * Tạo các sự kiện
 * CreatedBy:TXHMinh (9/7/2021)
 */
function initEvents() {
    var me = this;
    this.method = null;
    // Hiển thị form nhân viên mới khi nhấn nút thêm nhân viên
    $('#addEmp').on('click', function(){
        if(me.method == 'PUT') {
            $('.form-body-info-input').val(null);
        }
        showForm();
        me.method = 'POST';
    });

    // Hiển thi form nhân viên đã có sẵn khi nhấn đúp vào nhân viên trong bảng
    $('table').on('dblclick', 'tbody tr',function(){
        showForm();
        me.method = 'PUT';

        // Truyền dữ liệu từ bảng vào form
        var employeeid = $(this).attr('employeeid');
        $.ajax({
            url: "http://cukcuk.manhnv.net/v1/Employees/" + employeeid,
            method: 'Get',
        }).done(function(res){
            // Với mỗi trường nhập thông tin trong form
            var fieldinputs = $('.form-body-info-input');
            $.each(fieldinputs, function(index, item) {
                // Lấy dữ liệu từ biến res
                var value = $(res).attr(item.id);
                // Định dạng ngày tháng phù hợp với server
                if (item.type == "date") {
                    value = (new Date(value)).toISOString().slice(0, 10);
                }

                // Thêm vào từng mục input tương ứng qua id của phần tử html
                $(item).val(value);
            })
        }).fail(function(res) {

        })
    });

    // Lưu hoặc thêm thông tin nhân viên khi ấn nút lưu
    $('#form-save').on('click', me.saveEmployeeInfo.bind(me));

    // Reload dữ liệu khi bấm nút refresh
    $('#refresh-info').on('click', loadData);

    // Ẩn form nhân viên khi nhấn nút x hoặc hủy
    $('#form-close').on('click', hideForm);

    $('#form-cancel').on('click', hideForm);

    // Thêm viền đỏ cho các trường bắt buộc phải nhập
    $('.input-required').blur(function () {
        var value = $(this).val();
        if (!value) {
            $(this).addClass('border-red');
        } else {
            $(this).removeClass('border-red');
        }
    });

    // Thêm viền đỏ cho trường nhập email trong trường hợp nhập sai
    $('input[type="email"]').blur(function() {
        var emailaddr = $(this).val();
        var testemail = /\S+@\S+\.\S+/;
        if(!testemail.test(emailaddr)) {
            $(this).attr('title', 'Vui lòng nhập đúng định dạng email');
            $(this).addClass('border-red');
        } else {
            $(this).removeAttr('title', 'Vui lòng nhập đúng định dạng email');
            $(this).removeClass('border-red');
        }
    })
}

function addEmployee() {
    
}

/**
 * Lưu hoặc sửa thông tin nhân viên
 * CreatedBy: TXHMinh (12/7/2021)
 */
function saveEmployeeInfo(){
    var me = this;
    // Kiểm tra tất cả dữ liệu được nhập vào
    var inputValidates = $('.input-required, input[type="email"]');
    $.each(inputValidates, function(index, item) {
        $(this).trigger('blur');
    })

    // Nếu còn trường nhập dữ liệu chưa đủ điều kiện thì thông báo và autofocus
    var notValidInputs = $('.border-red');
    if(notValidInputs && notValidInputs.length > 0) {
        alert('Dữ liệu được nhập không hợp lệ')
        $('.border-red').first().focus();
        return;
    }

    // Build dữ liệu đc nhập thành object
    // + Format dữ liệu của các trường nhập ngày tháng năm sang dạng ISO
    var dateinputs = $('input[type = date]');
    $.each(dateinputs, function(index, item) {
        dateinputs[index] = $(item).val() === "" ? null : (new Date($(item).val())).toISOString();
    })

    // + Tạo object
    var employee = {};

    // Với mỗi trường nhập dữ liệu trong form, thêm dữ liệu vào object đã tạo
    var datainputs = $('.form-body-info-input');
    $.each(datainputs, function(index, item) {
        let value = $('#'+item.id).val();

        // Format ngày tháng và trường hợp để trống
        if(item.type == "date") {
            employee[item.id] = value === "" ? null : (new Date(value)).toISOString();
        } else {
            employee[item.id] = value === "" ? null : value;
        }
    })

    if(me.method == 'POST'){
        // + Thêm ngày tạo trong trường hợp thêm mới nhân viên
        employee["CreatedDate"] = (new Date()).toISOString();
    } else {
        // + Thêm ngày sửa trong trường hợp sửa thông tin nhân viên
        employee["ModifiedDate"] = (new Date()).toISOString();
    }
    
    // + Đẩy dữ liệu lên server
    $.ajax({
        url: "http://cukcuk.manhnv.net/v1/Employees",
        method: method,
        data: JSON.stringify(employee),
        contentType: 'application/json'
    }).done(function(res){
        alert('lưu thành công');
    
        // Ẩn form và reload lại dữ liệu
        me.hideForm();
        me.loadData();
    }).fail(function(res) {
        alert('không lưu đc bạn ơi');
    })
}

/**
 * Function để hiển thị form nhân viên
 * CreatedBy: TXHMinh (9/7/2021)
 */
function showForm() {
    $('.popupbackgr').show();
    $('.form').show();
    $('.form-body-info-input').first().focus();
}

/**
 * Function để ẩn form nhân viên
 * CreatedBy: TXHMinh (9/7/2021)
 */
function hideForm() {
    $('.popupbackgr').hide();
    $('.form').hide();
}

/**
 * Load dữ liệu
 * CreatedBy: TXHMinh (8/7/2021)
 */
function loadData() {
    // Lưu thông tin các cột dữ liệu từ file html vào biến ths
    var ths = $('table thead th');
    //Lấy dữ liệu về
    var dataUrl = "http://cukcuk.manhnv.net/v1/Employees";
    $.ajax({
        url: dataUrl,
        method: "GET",
    }).done(function (res) {
        // Lưu dữ liệu trong biến data
        var data = res;
        var tbody = $('<tbody></tbody>');

        // Với mỗi 1 nhân viên trong data (lưu nhân viên vào biến employee)
        $.each(data, function (indexemp, employee) {
            // Tạo dòng trong bảng
            var tr = $(`<tr employeeid = "${employee.EmployeeId}"></tr>`);

            // Lấy thông tin nhân viên map tương ứng vào từng cột trong html
            $.each(ths, function (indexinfo, item) {
                var field = $(item).attr('fieldname');
                var info = employee[field];
                var td = $(`<td></td>`);

                // Các trường hợp cần format định dạng
                switch (field) {
                    // Format giới tính
                    case ('GenderName'):
                        info = formatNull(info);
                        break;

                    //Format ngày sinh
                    case ('DateOfBirth'):
                        td.get(0).style.maxWidth = "100px";
                        td.get(0).style.textAlign = "center";
                        info = formatDate(info);
                        break;

                    // Format email
                    case ('Email'):
                        td.get(0).style.maxWidth = "225px";

                    // Format chức vụ
                    case ('QualificationName'):
                        info = formatNull(info);
                        break;

                    // Format phòng ban
                    case ('PositionName'):
                        info = formatNull(info);
                        break;

                    // Format tiền lương
                    case ('Salary'):
                        td.get(0).style.textAlign = "right";
                        info = formatSalary(info);
                        break;

                    // Format tình trạng công việc
                    case ('WorkStatus'):
                        info = formatWorkStatus(info);
                        break;
                }
                $(td).attr("fieldName", field);
                $(td).append(info);
                $(tr).append(td);
            })

            $(tbody).append(tr);
        })
        $('table tbody').remove();
        $('table').append(tbody);

    }).fail(function (res) {

    })
    //binding dữ liệu lên table

}

/**
 * Format các giá trị null
 * @param {*} genderName 
 * @returns 
 * CreatedBy: TXHMinh (8/7/2021)
 */
function formatNull(nullVariable) {
    return nullVariable == null ? "Khác" : nullVariable;
}

/** --------------------------------------
 * Format dữ liệu sang ngày/tháng/năm
 * @param {*} date 
 * CreatedBy: TXHMinh (6/7/2021)
 */
function formatDate(date) {
    var date = new Date(date);
    if (!date) {
        return "";
    } else {
        var day = date.getDate(),
            month = date.getMonth() + 1,
            year = date.getFullYear();
        day = day < 10 ? '0' + day : day;
        month = month < 10 ? '0' + month : month;

        return day + '/' + month + '/' + year;
    }
}

/** ----------------------------------
 * Hàm định dạng hiển thị tiền tệ
 * @param {Number} salary 
 * CreatedBy: TXHMinh (6/7/2021)
 */
function formatSalary(salary) {
    if (!salary) {
        return "Không xác định";
    } else {
        return salary.toFixed().replace(/(\d)(?=(\d{3})+$)/g, "$1.") + "₫";
    }
}

/**
 * Format tình trạng công việc
 * @param {*} workStatus 
 * CreatedBy: TXHMinh (8/7/2021)
 */
function formatWorkStatus(workStatus) {
    switch (workStatus) {
        case (null):
            return "Không xác định";
        case (-1):
            return "Đã nghỉ làm";
        case (0):
            return "Đang thử làm";
        case (1):
            return "Đang làm";
        case (2):
            return "Đang nghỉ lễ";
        case (3):
            return "Đã nghỉ làm";
    }
}