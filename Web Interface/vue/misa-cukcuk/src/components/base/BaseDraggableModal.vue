<template>
  <modal name="hello-world" :draggable="true" :height="850" :width="700">
    <p>hello, wosdfsdsdfsdfsdffrld!</p>
    <div class="employee-details">
      <div class="form">
        <div class="form-header text-title2">
          THÔNG TIN NHÂN VIÊN
          <button
            id="form-close"
            class="form-close"
            @click="closeForm"
          ></button>
        </div>
        <div class="form-body">
          <div class="form-body-profilepic">
            <div class="form-body-profilepic-pic"></div>
            <div class="text-bodycontent">
              (Vui lòng chọn ảnh có định dạng .jpg, .jpeg, .png, .gif)
            </div>
          </div>
          <div class="form-body-information">
            <div class="form-body-info-title text-labelfieldinput">
              A.THÔNG TIN CHUNG:
            </div>

            <BaseInputLabel
              v-for="field in fields.slice(0, 9)"
              :key="field.id"
              :field="field"
            />

            <div class="form-body-info-title text-labelfieldinput">
              B.THÔNG TIN CÔNG VIỆC:
            </div>

            <BaseInputLabel
              v-for="field in fields.slice(9)"
              :key="field.id"
              :field="field"
            />
          </div>
        </div>
        <div class="form-footer">
          <button
            id="form-save"
            class="misa-btn misa-iconbtn"
            @click="closeForm"
          >
            <div class="form-footer-saveiconbtn-icon misa-iconbtn-icon"></div>
            <div class="misa-iconbtn-text">Lưu</div>
          </button>
          <button
            id="form-cancel"
            class="misa-btn misa-secondbtn"
            @click="closeForm"
          >
            Hủy
          </button>
        </div>
      </div>
    </div>
  </modal>
</template>

<script>
import BaseInputLabel from "../../components/base/BaseInputLabel.vue";

export default {
  name: "the-modal",
  components: {
    BaseInputLabel,
  },
  props: {
    employee: {},
  },
  methods: {
    closeForm() {
      this.$emit("closeForm");
    },
  },
  data() {
    return {
        modal: {
            height:900,
        },
      fields: [
        {
          id: "EmployeeCode",
          text: "Mã nhân viên",
          required: true,
          type: "text",
          value: "",
        },
        {
          id: "FullName",
          text: "Họ và tên",
          required: true,
          type: "text",
          value: "",
        },
        {
          id: "DateOfBirth",
          text: "Ngày sinh",
          required: false,
          type: "date",
          value: "",
        },
        {
          id: "GenderName",
          text: "Giới tính",
          required: false,
          type: "text",
          value: "",
        },
        {
          id: "IdentityNumber",
          text: "Số CMND/Căn cước",
          required: true,
          type: "text",
          value: "",
        },
        {
          id: "IdentityDate",
          text: "Ngày cấp",
          required: false,
          type: "date",
          value: "",
        },
        {
          id: "IdentityPlace",
          text: "Nơi cấp",
          required: false,
          type: "text",
          value: "",
        },
        { id: "Email", text: "Email", required: true, type: "text", value: "" },
        {
          id: "PhoneNumber",
          text: "Số điện thoại",
          required: true,
          type: "text",
          value: "",
        },
        {
          id: "QualificationName",
          text: "Vị trí",
          required: false,
          type: "text",
          value: "",
        },
        {
          id: "PositionName",
          text: "Phòng ban",
          required: false,
          type: "text",
          value: "",
        },
        {
          id: "PersonalTaxCode",
          text: "Mã số thuế cá nhân",
          required: false,
          type: "text",
          value: "",
        },
        {
          id: "Salary",
          text: "Mức lương cơ bản",
          required: false,
          type: "text",
          value: "",
        },
        {
          id: "JoinDate",
          text: "Ngày gia nhập công ty",
          required: false,
          type: "date",
          value: "",
        },
        {
          id: "WorkStatus",
          text: "Tình trạng công việc",
          required: false,
          type: "text",
          value: "",
        },
      ],
    };
  },
};
</script>