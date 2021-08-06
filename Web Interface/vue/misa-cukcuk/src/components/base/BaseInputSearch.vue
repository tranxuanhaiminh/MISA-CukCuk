<template>
  <span class="misa-input-search">
    <input
      type="text"
      class="misa-input-text"
      :placeholder="textHolder"
    />
    <button class="misa-input-clearer"></button>
  </span>
</template>

<script>
export default {
    name: "BaseInputSearch",
    props: {
        textHolder: String
    }
}
</script>