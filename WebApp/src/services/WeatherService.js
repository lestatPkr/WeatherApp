import axios from 'axios'
import Forecast from '../models/Forecast.js'
import moment from 'moment'

class WeatherService {
  getCurrent (city) {
    return new Promise((resolve, reject) => {
      axios.defaults.crossDomain = true
      axios.get(`http://localhost:5000/api/Weather/current?city=` + city).then(response => {
        var day = moment(response.data.date)
        var forecast = new Forecast(response.data.city,
          response.data.temperature, response.data.windSpeed, response.data.humidity,
          day.date(), day.format('dddd'), response.data.weatherId)
        resolve(forecast)
      })
        .catch(e => {
          reject(e)
        })
    })
  }

  getForecast (city) {
    return new Promise((resolve, reject) => {
      axios.defaults.crossDomain = true
      axios.get(`http://localhost:5000/api/Weather/forecast?city=` + city).then(response => {
        var result = []
        console.log(response)
        response.data.forEach(function (element) {
          var day = moment(element.date)
          var forecast = new Forecast(element.city,
            element.temperature, element.windSpeed, element.humidity,
            day.date(), day.format('dddd'), element.weatherId)
          result.push(forecast)
        })
        resolve(result.splice(0, 5))
      })
        .catch(e => {
          reject(e)
        })
    })
  }
}

export default WeatherService
