<template>
  <div class="menu">
    <MenuItem
      class="menu-item text-bodycontent"
      v-for="item in items"
      :key="item.id"
      :menuText=item.text
      :icon=item.class
    />
  </div>
</template>

<style lang="css" src='../../css/layout/menu.css'></style>
<script>
import MenuItem from "./MenuItem.vue";

export default {
  name: "the-menu",
  components: {
    MenuItem,
  },
  data() {
    return {
      items: [
        { text: "Tổng quan", class: "icon-dashboard"},
        { text: "Báo cáo", class: "icon-report"},
        { text: "Mua hàng", class: "icon-shop"},
        { text: "Danh mục nhân viên", class: "icon-employee"},
        { text: "Thiết lập hệ thống", class: "icon-settings"},
      ]
    };
  },
};
</script>