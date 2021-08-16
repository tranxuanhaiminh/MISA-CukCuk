<template>
  <div id="app">
    <TheHeader />
    <TheMenu />
    <TheContent @showForm="showFormNew" @showFormDetails="showFormDetails"/>
    <EmployeeDetail v-show="isShow" @closeForm="closeForm" :employee = "employee"/>
  </div>
</template>

<script>
import TheHeader from "./components/layout/TheHeader.vue";
import TheMenu from "./components/layout/TheMenu.vue";
import EmployeeDetail from "./views/employee/EmployeeDetail.vue";
import TheContent from "./components/layout/ThePage.vue";

export default {
  name: "App",
  components: {
    TheHeader,
    TheMenu,
    EmployeeDetail,
    TheContent,
  },

  data() {
    return {
      isShow: false,
      employee: {}
    };
  },

  methods: {
    showFormNew() {
      this.isShow = true;
      this.employee = {}
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
