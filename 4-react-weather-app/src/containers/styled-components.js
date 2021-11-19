import styled from 'styled-components';
import img from '../img/searchsite-mg.png';

export const Form = styled.form`
  display: flex;
  align-self: center;
`;

export const Header = styled.h1`
  margin-left: 10px;
  font-size: 28px;
  font-weight: 300;

  @media (min-width: 320px) and (max-width: 430px) {
    margin-left: 0;
    font-size: 25px;
  }
`;

export const SearchBar = styled.div`
  position: relative;
`;

export const CitySearchContainer = styled.div`
  position: relative;
  display: flex;
  justify-content: center;
`;

export const SubmitButton = styled.button`
  position: absolute;
  top: 13px;
  right: 20px;
  background-image: url(${img});
  background-repeat: no-repeat;
  background-size: 25px 25px;
  width: 28px;
  height: 26px;
  border: none;
  background-color: transparent;
  cursor: pointer;
`;

export const CitySearch = styled.input`
  width: 70vw;
  height: 45px;
  background-color: rgba(243, 243, 243, 0.5);
  border-radius: 20px;
  padding-left: 10px;
  font-size: 16px;
  box-shadow: 0px 0px 87px -10px rgba(83, 106, 219, 1);

  @media (min-width: 320px) and (max-width: 370px) {
    width: 90vw;
  }
`;
