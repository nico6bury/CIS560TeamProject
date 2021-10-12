import React from "react";
import { Link } from "react-router-dom";
import styled from "styled-components";
import mainLogo from "../images/mainLogo.jpg";

export default function Header({ userName }) {
  return (
    <PageWrapper>
      <div className="headerMain">
        <img src={mainLogo} className="logo" alt="GURPS Book image"></img>
        <div className="headerTitle">GURPS Loot Random Generation</div>
        <div className="headerSub">
          <div>Welcome {userName}</div>
          <div className="links">
            <Link className="mainLink">Login</Link>
            <Link className="mainLink">Create Account</Link>
          </div>
        </div>
      </div>
    </PageWrapper>
  );
}

const PageWrapper = styled.nav`
  position: -webkit-sticky;
  position: sticky;
  //position: fixed;
  top: 0;
  //width: 100%;
  padding: 1rem 1.5rem;
  background: var(--darkPurpleColor);
  border-bottom: 5px solid var(--primaryOrangeColor);
  z-index: 999;
  .headerMain {
    display: flex;
    align-items: center;
    justify-content: space-around;
    flex-direction: row;
    //max-width: 1500px;
    margin: 5 auto;
  }
  .headerTitle {
    font-size: 2.5rem;
    color: white;
    text-transform: uppercase;
    letter-spacing: 0.12rem;
  }
  .headerSub {
    display: flex;
    align-items: left;
    flex-direction: column;
    font-size: 1rem;
    color: white;
  }
  .logo {
    height: 50%;
    width: 10%;
  }
  @media screen and (max-width: 500px) {
    .headerMain {
      float: none;
      display: block;
      text-align: left;
    }
    .header-right {
      float: none;
    }
  }

  .links {
    display: flex;
    flex-direction: column;
    margin-bottom: 3px;
  }
`;
