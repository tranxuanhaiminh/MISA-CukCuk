<template>
  <div class="grid text-label">
    <table border="0" width="100%" cellspacing="0">
      <thead>
        <tr>
          <th v-for="th in ths" :key="th.id" :fieldname="th.field">
            {{ th.text }}
          </th>
        </tr>
      </thead>
      <tbody>
        <tr
          v-for="(employee, index) in employees"
          :key="employee.id"
          :class = "employees[index].EmployeeId"
          @dblclick="showDetails($event)"
        >
          <td v-for="th in ths" :key="th.id">
            {{ employee[th.field] }}
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {
  name: "BaseTable",
  props: {
    employees: [],
    ths: [],
  },
  data() {
    return {};
  },
  methods: {
    showDetails(event) {
      this.$emit("showDetails", event);
    },
  },
};
</script>