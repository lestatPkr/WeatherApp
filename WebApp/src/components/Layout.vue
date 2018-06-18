<template>
  <div class="container-fluid">
    <Header></Header>
    <div class="row">
      <search-box v-on:city-changed="cityChanged"/>
    </div>
    <div class="row">

      <section id="main-section" class="col-lg-6 offset-lg-3">
        <current-weather :city="selectedCity"/>
      </section>
      <section id="main-section" class="col-lg-6 offset-lg-3">
        <five-days-forecast :city="selectedCity"/>
      </section>
    </div>

  </div>
</template>

<script>
import Header from './Header'
import CurrentWeather from './CurrentWeather'
import FiveDaysForecast from './FiveDaysForecast'
import SearchBox from './SearchBox'
export default {
  name: 'Layout',
  components: {
    Header,
    CurrentWeather,
    FiveDaysForecast,
    SearchBox
  },
  data () {
    return {
      selectedCity: 'Madrid'
    }
  },
  methods: {
    cityChanged(args){
      this.selectedCity = args
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
