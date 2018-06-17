<template>
  <div class="row">
      <h1>The weather app</h1>
  </div>
</template>

<script>
export default {
  name: 'wa-header',
  data () {
    return {
      title: 'Welcome to the Weather App'
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  h1{
    width: 100%;
    text-align: center;
    height: 100px;
  }
</style>
