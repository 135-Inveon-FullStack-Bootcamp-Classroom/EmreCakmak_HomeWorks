//add and remove places actions on redux store
const reducer = (state = [], action) => {
  switch (action.type) {
    case 'ADD_PLACE':
      const newPlace = action.payload;
      const checkSamePlace = state.filter((place) => {
        return place.id === action.payload.id;
      });

      if (checkSamePlace.length !== 0) {
        return state;
      }

      return [...state, newPlace];

    case 'REMOVE_PLACE':
      return state.filter((place) => place.id !== action.id);

    default:
      return state;
  }
};

export default reducer;
