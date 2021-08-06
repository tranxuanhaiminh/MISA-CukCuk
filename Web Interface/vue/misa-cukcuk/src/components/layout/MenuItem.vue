<template>
  <div>
    <div class="menu-item-icon" :class=icon></div>
    <div>{{ menuText }}</div>
  </div>
</template>

<script>
export default {
  name: "MenuItem",
  props: {
    menuText: String,
    icon:String
  },
};
</script>