<template>
  <h2>In List:</h2>

<list-view-component
    :dataSource="entries"
    :fields="{ text: 'title', id: 'title' }"
    :template="cTemplate"
  />

</template>

<script>
import { ListViewComponent } from "@syncfusion/ej2-vue-lists";
import { createApp } from "vue";
const app = createApp({});

var listTemplate = app.component('cTemplate', {
  data: () => ({}),
  template:`<h4>{{data.title}} </h4>`
});

export default {
  name: "list",
  components: {
      "list-view-component": ListViewComponent,
  },
  data() {
      const entries = [{ title: "Lorem" }, { title: "ipsum" }];
    return {
        entries,
      cTemplate: function() {
        return {
          template: listTemplate,
        };
      },
    };
  },
};
</script>
<style>
@import "../node_modules/@syncfusion/ej2-base/styles/material.css";
@import "../node_modules/@syncfusion/ej2-inputs/styles/material.css";
@import "../node_modules/@syncfusion/ej2-vue-dropdowns/styles/material.css";
button {
  margin: 25px 5px 20px 20px;
}
</style>
