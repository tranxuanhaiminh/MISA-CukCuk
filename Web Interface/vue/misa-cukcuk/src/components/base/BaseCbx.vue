<template>
  <div class="misa-cbx-wrapper">
    <div class="misa-cbx">
      <input class="misa-cbx-select" :value=options[0].text />
      <div class="misa-cbx-arrow"></div>
      <div class="misa-cbx-list">
        <span
          class="misa-cbx-option"
          v-for="(option, index) in options"
          :key="option.id"
          :class="{'misa-cbx-selected':index === 0}"
          >{{ option.text }}</span
        >
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "BaseCbx",
  props: {
    options: Array,
  },
};
</script>