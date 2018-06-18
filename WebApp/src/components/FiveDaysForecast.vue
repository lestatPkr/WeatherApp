<template>
<div class="wa-container">

 <section class="row">
    <div v-for="(item, index) in forecast" :key="index"  class="wa-div-data col">
      <div class="wa-div-icon">
        <weather-icon :weatherId="item.weather" class="weather-icon"/>
      </div>
      <h3>{{item.day}}</h3>
      <h4>{{item.dayOfWeek.substring(0,3)}}</h4>
      <span><i class="wi wi-thermometer"></i> {{item.temperature}}ºC</span> </br>
      <span><i class="wi wi-strong-wind"></i> {{item.windSpeed}} m/s</span> </br>
      <span><i class="wi wi-humidity"></i> {{item.humidity}}%</span> </br>
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
  name: 'FiveDaysForecast',
  components: {
    WeatherIcon
  },
  props:[
    'city'
  ],
  data () {
    return {
      forecast: [],
      errors: []

    }
  },
  methods:{
    updateData(){
      var api =  new WeatherService();
      api.getForecast(this.$props.city)
      .then(response => {
        this.forecast = response
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
    text-align: center;
    width: 100%;
    padding: 20px ;

    margin: 10px;
  }
  section{
    max-width: 550px;
    margin: 0 auto;
  }
  section>div{
    margin-left:5px;
    background-color:#636363;
  }
  section:first-child{
    margin-top:20px;
  }
  .weather-icon{
    font-size: 5px
  }



</style>
