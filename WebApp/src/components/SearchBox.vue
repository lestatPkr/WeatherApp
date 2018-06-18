<template>
  <div class="wa-search-box">
    <autocomplete
    url="https://andruxnet-world-cities-v1.p.mashape.com/"
    anchor="city"
    label="city"
    :onSelect="getData"
    :customParams="{ searchby: 'city' }"
    param="query"
    :customHeaders="headers"
    :required="true"
    placeholder="Select your city"
    :initValue="selectedCity"
    :options="[]"
    :min="3"
    :filterByAnchor="true"
    :encodeParams="true"


  >
  </autocomplete>

  </div>
</template>

<script>

import Autocomplete from 'vue2-autocomplete-js'
export default {
  name: 'SearchBox',
  components: {
    Autocomplete
  },
  data () {
    return {
      selectedCity: 'Madrid',
      headers: {
        'X-Mashape-Key': 'r1LTsU0lybmshARCFYr8PRpAuh28p1v4P4FjsnY1d7eMQi2yPl',
        'Accept' : 'application/json'
       },
    }
  },
  methods: {
    getData(obj){
      this.$data.selectedCity = obj.city;
      this.$emit("city-changed", this.$data.selectedCity)
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>
.wa-search-box{
  margin: 0 auto;
}
.transition, .autocomplete, .showAll-transition, .autocomplete ul, .autocomplete ul li a{
  transition:all 0.3s ease-out;
  -moz-transition:all 0.3s ease-out;
  -webkit-transition:all 0.3s ease-out;
  -o-transition:all 0.3s ease-out;
}

.autocomplete ul{
  font-family: sans-serif;
  position: absolute;
  list-style: none;
  background: #f8f8f8;
  padding: 10px 0;
  margin: 0;
  display: inline-block;
  min-width: 15%;
  margin-top: 10px;
  z-index: 5000;
}
.autocomplete-list{
  position: relative;
  left: -50px;
  width: 350px;
}
.autocomplete ul:before{
  content: "";
  display: block;
  position: absolute;
  height: 0;
  width: 0;
  border: 10px solid transparent;
  border-bottom: 10px solid #f8f8f8;
  left: 46%;
  top: -20px
}

.autocomplete ul li a{
  text-decoration: none;
  display: block;
  background: #f8f8f8;
  color: #2b2b2b;
  padding: 5px;
  padding-left: 10px;
}

.autocomplete ul li a:hover, .autocomplete ul li.focus-list a{
  color: white;
  background: #2F9AF7;
}

.autocomplete ul li a span, /*backwards compat*/
.autocomplete ul li a .autocomplete-anchor-label{
  display: block;
  margin-top: 3px;
  color: grey;
  font-size: 13px;
}

.autocomplete ul li a:hover .autocomplete-anchor-label,
.autocomplete ul li.focus-list a span, /*backwards compat*/
.autocomplete ul li a:hover .autocomplete-anchor-label,
.autocomplete ul li.focus-list a span{ /*backwards compat*/
  color: white;
}

/*.showAll-transition{
  opacity: 1;
  height: 50px;
  overflow: hidden;
}

.showAll-enter{
  opacity: 0.3;
  height: 0;
}

.showAll-leave{
  display: none;
}*/

</style>
