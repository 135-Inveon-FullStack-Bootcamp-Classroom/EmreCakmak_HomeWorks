import styled, { keyframes } from 'styled-components';
import img from '../img/remove.png';

const fadeIn = keyframes`
  0% {
    opacity: 0;
  }

  100% {
    opacity: 1;
  }
`;

const shake = keyframes`
  0% {
    transform: rotate(5deg);
  }

  50% {
    transform: rotate(-5deg);
  }

  100% {
    transform: rotate(5deg);
  }
`;

export const Wrapper = styled.div`
  display: flex;
  justify-content: center;
  flex-wrap: wrap;
`;

export const ErrorMsg = styled.p`
  text-align: center;
  margin-top: 20px;
  font-size: 20px;
  font-weight: 300;
`;

export const Container = styled.div`
  position: relative;
  display: flex;
  justify-content: space-around;
  align-items: center;
  margin: 10vh 5vh;
  min-width: 25vw;
  max-width: 60vw;
  min-height: 100px;
  max-height 40vh;
  border: 1px solid rgba(89, 79, 179, 0.4);
  border-radius: 20px;
  background-color: rgba(221, 232, 237, 0.7);
  animation: ${fadeIn} 1s;

  @media (min-width: 320px) and (max-width: 430px) {
    min-width: 90vw;
    margin: 4vh 5vh;
  }
`;

export const City = styled.span`
  padding-left: 10px;
  font-size: 50px;
  color: #1f5169;
  line-height: 0.9;

  @media (min-width: 320px) and (max-width: 570px) {
    font-size: 32px;
  }
`;

export const Temperature = styled.span`
  padding-top: 10px;
  padding-left: 10px;
  padding-right: 10px;
  font-size: 30px;
  color: red;

  @media (min-width: 320px) and (max-width: 430px) {
    padding-top: 0;
  }
`;

export const Description = styled.span`
  display: flex;
  align-self: flex-end;
  padding-right: 15px;
  padding-bottom: 5px;
  font-size: 14px;
  line-height: 0.99;

  @media (min-width: 320px) and (max-width: 430px) {
    padding-bottom: 0;
    align-self: center;
  }
`;

export const RemoveButton = styled.button`
  position: absolute;
  top: 5px;
  right: 5px;
  width: 25px;
  height: 25px;
  background-image: url(${img});
  background-size: 24px 25px;
  background-repeat: no-repeat;
  background-color: transparent;
  border: none;
  cursor: pointer;

  &:hover {
    animation: ${shake} 0.17s infinite;
  }
`;
