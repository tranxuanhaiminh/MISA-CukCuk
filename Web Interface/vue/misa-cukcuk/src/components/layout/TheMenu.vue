<template>
  <div class="menu">
    <MenuItem
      class="menu-item text-bodycontent"
      v-for="item in items"
      :key="item.id"
      :menuText=item.text
      :icon=item.class
      :route=item.route
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
        { text: "Tổng quan", class: "icon-dashboard", route: "/"},
        { text: "Báo cáo", class: "icon-report", route: "/danh-muc/nhan-vien"},
        { text: "Mua hàng", class: "icon-shop", route: "/danh-muc/nhan-vien"},
        { text: "Danh mục nhân viên", class: "icon-employee", route: "/danh-muc/nhan-vien"},
        { text: "Danh mục khách hàng", class: "icon-employee", route: "/danh-muc/khach-hang"},
        { text: "Thiết lập hệ thống", class: "icon-settings", route: "/danh-muc/nhan-vien"},
      ]
    };
  },
};
</script>