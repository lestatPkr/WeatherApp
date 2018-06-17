<template>
<div class="wa-container">

 <section class="row">
    <div class="wa-div-data">
       <h1>{{current.city}}</h1>
      <h2>{{current.dayOfWeek}}, {{current.day}}</h2>
      <h3><span><i class="wi wi-thermometer"></i></span> {{current.temperature}}ºC</h3>
      <h4><span><i class="wi wi-strong-wind"></i></span> {{current.windSpeed}} m/s</h4>
      <h4><span><i class="wi wi-humidity"></i></span> {{current.humidity}}%</h4>
    </div>
    <div class="wa-div-icon">
      <weather-icon :weatherId="current.weather" class="weather-icon"/>
    </div>
  </section>
</div>

</template>

<script>
import WeatherService from '../services/WeatherService.js'
import moment from 'vue-moment'
import Forecast from '../models/Forecast.js';
import WeatherIcon from './WeatherIcon'
export default {
  name: 'CurrentWeather',
  components: {
    WeatherIcon
  },
  data () {
    return {
      current: Forecast,
      errors: []

    }
  },
  created() {
    var api =  new WeatherService();
    api.getCurrent()
    .then(response => {
      this.current = response
    })
    .catch(e => {
      this.errors.push(e)
    })
  }

}
</script>

<style scoped>
 .wa-container{
    text-align: left;
    width: 100%;
    background-color:#636363;
    padding: 20px 60px;
  }
  section{
    max-width: 600px;
    margin: 0 auto;
  }
  section:first-child{
    margin-top:20px;
  }
  .weather-icon{
    font-size: 25px
  }

  .wa-div-data, .wa-div-icon{
    width: 50%;
  }
</style>
