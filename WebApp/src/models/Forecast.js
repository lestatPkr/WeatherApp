class Forecast {
  constructor (city, temperature, windSpeed, humidity, day, dayOfWeek, weatherId) {
    this.city = city
    this.temperature = temperature
    this.windSpeed = windSpeed
    this.humidity = humidity
    this.day = day
    this.dayOfWeek = dayOfWeek
    this.weatherId = weatherId
    this.weather = this.getWeather(weatherId)
  }
  getWeather (weatherId) {
    switch (weatherId) {
      case 2:
        return 'Thunderstorm'
      case 3:
        return 'Drizzle'
      case 5:
        return 'Rain'
      case 6:
        return 'Snow'
      case 7:
        return 'Clouds'
      default:
        return 'Clear'
    }
  }
}
export default Forecast
