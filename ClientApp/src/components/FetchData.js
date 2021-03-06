import React, { Component } from 'react';
const axios = require('axios');

export class FetchData extends Component {
  displayName = FetchData.name

  constructor() {
    super();
    this.state = { forecasts: [], loading: true };
    
    axios({
      method: 'get',
      url: 'api/SampleData/WeatherForecasts',
      headers: { 'Authorization': `Bearer ${this.state.token}` }
    })
    .then(response => {
      this.setState({ forecasts: response.data, loading: false });
    })
    .catch(error => console.log('error', error))
  }

  static renderForecastsTable(forecasts) {
    return (
      <table className='table'>
        <thead>
          <tr>
            <th>Date</th>
            <th>Temp. (C)</th>
            <th>Temp. (F)</th>
            <th>Summary</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map(forecast =>
            <tr key={forecast.dateFormatted}>
              <td>{forecast.dateFormatted}</td>
              <td>{forecast.temperatureC}</td>
              <td>{forecast.temperatureF}</td>
              <td>{forecast.summary}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderForecastsTable(this.state.forecasts);

    return (
      <div>
        <h1>Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }
}
