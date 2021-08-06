<template>
  <button :id="btnid" class="misa-btn misa-iconbtn" @click="callback($event)">
    <div class="misa-iconbtn-icon" :class="btnicon"></div>
    <div class="misa-iconbtn-text">{{ btntext }}</div>
  </button>
</template>

<script>
export default {
  name: "BaseIconButton",
  props: {
    btnid: String,
    btnicon: String,
    btntext: String,
  },
  methods:{
    callback: function(e) {
      this.$emit('click', e);
    }
  }
};
</script>