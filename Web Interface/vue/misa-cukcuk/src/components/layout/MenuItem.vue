<template>
  <router-link :to=route>
    <div class="menu-item-icon" :class=icon></div>
    <div>{{ menuText }}</div>
  </router-link>
</template>

<script>
export default {
  name: "MenuItem",
  props: {
    menuText: String,
    icon:String,
    route:String
  },
};
</script>