<template>
  <div class="container-fluid">
    <Header></Header>
    <div class="row">
      <section id="main-section" class="col-lg-6 offset-lg-3">
        <current-weather/>
      </section>
    </div>

  </div>
</template>

<script>
import Header from './Header'
import CurrentWeather from './CurrentWeather'
export default {
  name: 'Layout',
  components: {
    Header,
    CurrentWeather
  },
  data () {
    return {
      title: 'Welcome to the Weather App'
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
