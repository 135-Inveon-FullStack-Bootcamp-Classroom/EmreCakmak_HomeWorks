import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux';
import { getPlace, removePlace } from '../actions/';

import PlacesBoard from '../components/places-board';
import {
  Form,
  SearchBar,
  CitySearchContainer,
  CitySearch,
  SubmitButton,
  Header,
} from './styled-components';

let App = (props) => {
  const [city, setCity] = useState('');
  const { places, removePlace } = props;

  //city information api call
  useEffect(() => {
    if (places.length === 0) {
      const userLocation = fetch('https://extreme-ip-lookup.com/json/')
        .then((res) => res.json())
        .then((res) => props.getPlace(res.city));
    }
  });

  //change first letter to uppercase given on the search input value,then send input value to the redux actions
  const sendData = () => {
    const modifiedStringForRequest =
      city.charAt(0).toUpperCase() + city.slice(1);

    if (modifiedStringForRequest.length > 0) {
      props.getPlace(modifiedStringForRequest);
    }
  };

  //take the search input value
  const handleSubmit = (e) => {
    e.preventDefault();
    sendData();
    setCity('');
  };

  return (
    <div className="center">
      <Form>
        <SearchBar>
          <Header>Find weather in any place</Header>
          <CitySearchContainer>
            <CitySearch
              type="text"
              placeholder="Enter your city:"
              onChange={(e) => setCity(e.target.value)}
              value={city}
            />
            <SubmitButton type="submit" onClick={(e) => handleSubmit(e)} />
          </CitySearchContainer>
        </SearchBar>
      </Form>
      <PlacesBoard cities={places} removePlace={removePlace} />
    </div>
  );
};

function mapStateToProps(state) {
  return {
    places: state,
  };
}

function mapDispatchToProps(dispatch) {
  return {
    getPlace: (city) => dispatch(getPlace(city)),
    removePlace: (id) => dispatch(removePlace(id)),
  };
}

App = connect(mapStateToProps, mapDispatchToProps)(App);

export default App;
