<template>
  <div>
    <div v-if="error" class="alert alert-danger" role="alert">
      <ul>
        <li>{{ error }}</li>
      </ul>
    </div>
    <div class="row">
      <div class="col-sm-8">
        <h1>Categorias</h1>
      </div>
      <div class="col-sm-4">
        <div class="search-box" style="margin-top: 10px">
          <input
            type="text"
            class="form-control"
            placeholder="Descrição"
            v-on:blur="onBlurSearch"
          />
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-sm-10"></div>
      <div class="col-sm-2" style="text-align: right; margin: 15px 0px;">
        <router-link
          :to="{ name: 'CreateCategoria' }"
          class="btn btn-outline-secondary"
          >Add Categoria</router-link
        >
      </div>
    </div>

    <table class="table table-hover">
      <thead>
        <tr>
          <td>Id</td>
          <td>Código</td>
          <td>Descrição</td>
          <td>Data Criação</td>
          <td colspan="2">Actions</td>
        </tr>
      </thead>

      <tbody>
        <tr v-for="item in items" :key="item.id">
          <td>{{ item.id }}</td>
          <td>{{ item.codigo }}</td>
          <td>{{ item.descricao }}</td>
          <td>{{ item.criadoEm | date }}</td>
          <td>
            <router-link
              :to="{ name: 'EditCategoria', params: { id: item.id } }"
              class="btn btn-outline-primary"
              >Edit</router-link
            >
          </td>
          <td>
            <button
              class="btn btn-outline-danger"
              v-on:click="deleteItem(item.id)"
            >
              Delete
            </button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {
  data() {
    return {
      items: [],
      error: null,
    };
  },

  created: function() {
    this.fetchItems();
  },

  methods: {
    fetchItems() {
      let uri = "https://localhost:44328/api/categorias";
      this.axios.get(uri).then((response) => {
        this.items = response.data;
      });
    },
    deleteItem(id) {
      let uri = "https://localhost:44328/api/categorias/" + id;

      this.axios
        .delete(uri)
        .then(() => {
          this.items.splice(id, 1);
        })
        .catch((error) => {
          this.error = error.response.data;
        });
    },
    onBlurSearch(event) {
      let uri =
        "https://localhost:44328/api/categorias/search?descricao=" +
        event.srcElement.value;
      this.axios.get(uri).then((response) => {
        this.items = response.data;
      });
    },
  },
};
</script>
