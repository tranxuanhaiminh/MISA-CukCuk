<template>
  <div class="form-body-info-detail">
    <div class="text-labelfieldinput">
      <span>{{field.text}}</span><span v-if="field.required" class="text-required">(*)</span>
    </div>
    <input
      :type="field.type"
      :id="field.id"
      class="form-body-info-input misa-input input-required"
      v-model="field.value"
    />
  </div>
</template>

<script>
export default {
  name: "BaseInputLabel",
  props: {
    field: {},
  },
};
</script>