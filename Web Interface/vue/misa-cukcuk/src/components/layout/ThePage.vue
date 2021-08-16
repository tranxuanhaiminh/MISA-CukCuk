<template>
  <div>
    <router-view @showForm="showFormNew" @showFormDetails="showFormDetails" />
  </div>
</template>

<script>
export default {
  name: "TheContent",
  components:{
  },
  props: {},
  methods: {
    showFormNew: function () {
      this.$emit("showForm");
    },
    showFormDetails: function() {
        this.$emit("showFormDetails");
    }
  },
};
</script>