import React from 'react';
import {
  Wrapper,
  ErrorMsg,
  Container,
  City,
  Temperature,
  Description,
  RemoveButton,
} from './styled-components';

const PlacesBoard = (props) => {
  const { cities, removePlace } = props;
  const citiesReversed = [...cities].reverse();
  const citiesToRender = citiesReversed.filter((city) => city.cod === 200);

  //check if city is exist or not
  if (cities.length === 0) {
    return <ErrorMsg>No places to show yet</ErrorMsg>;
  }

  return (
    <Wrapper>
      {citiesToRender.map((city) => {
        return (
          <Container key={city.id}>
            <City>{city.name}</City>
            <Temperature>{city.main.temp.toFixed(1)}&deg;C</Temperature>
            <Description>{city.weather[0].description}</Description>
            <RemoveButton onClick={() => removePlace(city.id)}></RemoveButton>
          </Container>
        );
      })}
    </Wrapper>
  );
};

export default PlacesBoard;
