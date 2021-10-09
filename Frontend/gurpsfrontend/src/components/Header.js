import React from "react";
import { Link } from "react-router-dom";
import styled from "styled-components";
import mainLogo from "../images/mainLogo.jpg";

export default function Header() {
  return (
    <PageWrapper>
      <img src="mainLogo.jpg"></img>
      <h1>GURPS Loot Random Generation Table</h1>
      <div className="links">
        <Link className="mainLink">Login</Link>
        <Link className="mainLink">Create Account</Link>
      </div>
    </PageWrapper>
  );
}

const PageWrapper = styled.nav`
  display: flex;
  flex-direction: row;
  align-items: center;
  background-color: var(--secondaryPurpleColor);
  color: white;
  justify-content: space-between;
  margin-left: 0px;
  margin-right: 0px;
  margin-top: 0px;

  .links {
    display: flex;
    flex-direction: column;
    margin-bottom: 3px;
  }
`;
