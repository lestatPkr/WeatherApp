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
  props:[
    'city'
  ],
  data () {
    return {
      current: Forecast,
      errors: []

    }
  },
  methods:{
    updateData(){
      var api =  new WeatherService();
      api.getCurrent(this.$props.city)
      .then(response => {
        this.current = response
      })
      .catch(e => {
        this.errors.push(e)
      })
    }
  },
  watch: {
    city: function (newCity, oldCity) {
      this.updateData()
    }
  },
  created(){
    this.updateData()
  }


}
</script>

<style scoped>
 .wa-container{
    text-align: left;
    width: 100%;
    padding: 20px ;
    background-color:#636363;
    margin: 10px
  }
  section{
    max-width: 550px;
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
  .wa-div-icon{
    position: relative;
    left: -60px;
  }
</style>
