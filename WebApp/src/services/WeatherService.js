import axios from 'axios'
import Forecast from '../models/Forecast.js'
import moment from 'moment'

class WeatherService {
  getCurrent () {
    return new Promise((resolve, reject) => {
      axios.defaults.crossDomain = true
      axios.get(`http://localhost:5000/api/Weather/current?city=madrid`).then(response => {
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
}

export default WeatherService
