<template>
  <div id="app">
    <TheHeader />
    <TheMenu />
    <TheContent @showForm="show" @showFormDetails="showFormDetails" />
    <EmployeeDetail
      v-show="isShow"
      @closeForm="closeForm"
      :employee="employee"
    />
    <BaseDraggableModal
      @closeForm="closeForm"
      :employee="employee"/>
  </div>
</template>

<script>
import TheHeader from "./components/layout/TheHeader.vue";
import TheMenu from "./components/layout/TheMenu.vue";
import EmployeeDetail from "./views/employee/EmployeeDetail.vue";
import TheContent from "./components/layout/ThePage.vue";
import BaseDraggableModal from "./components/base/BaseDraggableModal.vue";

export default {
  name: "App",
  components: {
    TheHeader,
    TheMenu,
    EmployeeDetail,
    TheContent,
    BaseDraggableModal,
  },

  data() {
    return {
      height:600,
      isShow: false,
      employee: {},
    };
  },

  methods: {
    show() {
      this.$modal.show("hello-world");
    },
    hide() {
      this.$modal.hide("hello-world");
    },
    showFormNew() {
      this.isShow = true;
      this.employee = {};
    },

    closeForm() {
      this.isShow = false;
    },

    showFormDetails(data) {
      this.employee = data;
      this.isShow = true;
    },
  },
};
</script>

<style>
@import "./css/common/main.css";
@import "./css/common/btn.css";
@import "./css/common/cbx.css";
@import "./css/common/drop.css";
@import "./css/common/form.css";
@import "./css/common/grid.css";
@import "./css/common/input.css";
@import "./css/common/paging.css";
</style>
