<template>
  <div>
    <div :class="{'misa-loading': isHide}"></div>
  </div>
</template>

<script>
export default {
  props: {
    isHide: {
      type: Boolean,
      default: true,
    },
  },
};
</script>