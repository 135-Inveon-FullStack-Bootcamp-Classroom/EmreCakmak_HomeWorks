const ADD_PLACE = 'ADD_PLACE';
const REMOVE_PLACE = 'REMOVE_PLACE';

//api call to get city deegrees then add to store
export function getPlace(city) {
  return async (dispatch) => {
    const URL = `https://api.openweathermap.org/data/2.5/weather?q=${city}&units=metric&appid=c1c65e8c14789cb2db58e95fa09939cd`;

    return fetch(URL)
      .then((res) => res.json())
      .then((payload) => dispatch(addPlace(payload)))
      .catch((error) => console.error(error));
  };
}

//add method to the store
function addPlace(payload) {
  return {
    type: ADD_PLACE,
    payload,
  };
}
//remove method from the store
export function removePlace(id) {
  return {
    type: REMOVE_PLACE,
    id,
  };
}
