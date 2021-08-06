<template>
  <div class="misa-pagingbar">
    <div class="misa-pagingbar-leftinfo text-contentdetail">
      Hiển thị 1-10/1000 nhân viên
    </div>
    <div class="misa-pagingbar-pagination">
      <a
        class="misa-pagination misa-pagination-icon misa-pagination-firstpage"
      ></a>
      <a
        class="misa-pagination misa-pagination-icon misa-pagination-prevpage"
      ></a>
      <a class="misa-pagination misa-pagination-number misa-paging-selected"
        >1</a
      >
      <a class="misa-pagination misa-pagination-number">2</a>
      <a class="misa-pagination misa-pagination-number">3</a>
      <a class="misa-pagination misa-pagination-number">4</a>
      <a
        class="misa-pagination misa-pagination-icon misa-pagination-nextpage"
      ></a>
      <a
        class="misa-pagination misa-pagination-icon misa-pagination-lastpage"
      ></a>
    </div>
    <div class="misa-pagingbar-rightinfo text-contentdetail">
      10 nhân viên/trang
    </div>
  </div>
</template>

<script>
export default {
  name: "BasePagination",
};
</script>