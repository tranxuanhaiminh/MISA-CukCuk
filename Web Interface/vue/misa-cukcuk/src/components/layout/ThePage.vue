<template>
  <div class="page">
    <div class="page-head">
      <div class="page-head-text text-heading">Danh sách nhân viên</div>
      <BaseIconButton
        btnid="addEmp"
        btnicon="page-head-iconbtn-icon"
        btntext="Thêm nhân viên"
        @click="showForm"
      />
    </div>

    <div class="page-search">
      <div class="page-search-filter">
        <BaseInputSearch
          textHolder="Tìm kiếm theo Mã, Tên hoặc Số điện thoại"
        />
        <BaseCbx :options="cbx1" />
        <BaseCbx :options="cbx2" />
      </div>
      <BaseSecondButton id="refresh-employees" class="refreshbtn" />
    </div>
    <BaseTable
      :employees="employees"
      :ths="ths"
      @showDetails="showFormDetails"
    />

    <BasePagination />
  </div>
</template>

<style lang="css" src='../../css/layout/page.css'></style>

<script>
import axios from "axios";
import BaseIconButton from "../base/BaseIconButton.vue";
import BaseSecondButton from "../base/BaseSecondButton.vue";
import BaseInputSearch from "../base/BaseInputSearch.vue";
import BaseCbx from "../base/BaseCbx.vue";
import BaseTable from "../base/BaseTable.vue";
import BasePagination from "../base/BasePagination.vue";

export default {
  name: "the-page",
  components: {
    BaseIconButton,
    BaseSecondButton,
    BaseInputSearch,
    BaseCbx,
    BaseTable,
    BasePagination,
  },
  created() {},
  mounted: function () {
    axios
      .get("http://cukcuk.manhnv.net/v1/Employees")
      .then((res) => {
        res.data.forEach((data, index) => {
          this.employees.push({ EmployeeId: data.EmployeeId });
          this.ths.forEach((column) => {
            let info = data[column.field];

            // Các trường hợp cần format định dạng
            switch (column.field) {
              // Format giới tính
              case "GenderName":
                info = formatNull(info);
                break;

              //Format ngày sinh
              case "DateOfBirth":
                info = formatDate(info);
                break;

              // Format email
              // case "Email":
              // td.get(0).style.maxWidth = "225px";

              // Format chức vụ
              case "QualificationName":
                info = formatNull(info);
                break;

              // Format phòng ban
              case "PositionName":
                info = formatNull(info);
                break;

              // Format tiền lương
              case "Salary":
                // td.get(0).style.textAlign = "right";
                info = formatSalary(info);
                break;

              // Format tình trạng công việc
              case "WorkStatus":
                info = formatWorkStatus(info);
                break;
            }
            this.employees[index][column.field] = info;
          });
        });
      })
      .catch();
  },
  props: {},
  methods: {
    showForm: function () {
      this.$emit("showForm");
    },
    showFormDetails(event) {
      var employeeId = event.target.parentElement.className;
      axios
        .get("http://cukcuk.manhnv.net/v1/Employees/" + employeeId)
        .then((res) => {
          this.$emit("showFormDetails", res.data);
        })
        .catch();
    },
  },
  data() {
    return {
      cbx1: [
        { text: "Tất cả phòng ban" },
        { text: "Phòng đào tạo" },
        { text: "Phòng tuyển sinh" },
        { text: "Ban ngiệp vụ" },
        { text: "Ban kế toán" },
        { text: "Ban giám đốc" },
      ],
      cbx2: [
        { text: "Tất cả vị trí" },
        { text: "Trưởng phòng" },
        { text: "Phó phòng" },
        { text: "Nhân viên" },
      ],
      ths: [
        { field: "EmployeeCode", text: "Mã nhân viên" },
        { field: "FullName", text: "Họ và tên" },
        { field: "GenderName", text: "Giới tính" },
        { field: "DateOfBirth", text: "Ngày sinh" },
        { field: "PhoneNumber", text: "Số điện thoại" },
        { field: "Email", text: "Email" },
        { field: "QualificationName", text: "Phòng ban" },
        { field: "PositionName", text: "Chức vụ" },
        { field: "Salary", text: "Mức lương cơ bản" },
        { field: "WorkStatus", text: "Tình trạng công việc" },
      ],
      employees: [],
    };
  },
};

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
function formatDate(dateParameter) {
  var date = new Date(dateParameter);
  if (!date) {
    return "";
  } else {
    var day = date.getDate(),
      month = date.getMonth() + 1,
      year = date.getFullYear();
    day = day < 10 ? "0" + day : day;
    month = month < 10 ? "0" + month : month;

    return day + "/" + month + "/" + year;
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
    case null:
      return "Không xác định";
    case -1:
      return "Đã nghỉ làm";
    case 0:
      return "Đang thử làm";
    case 1:
      return "Đang làm";
    case 2:
      return "Đang nghỉ lễ";
    case 3:
      return "Đã nghỉ làm";
  }
}
</script>