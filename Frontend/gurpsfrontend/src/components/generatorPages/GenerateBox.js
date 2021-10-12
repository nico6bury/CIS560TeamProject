import React, { useState, useEffect } from "react";
import styled from "styled-components";

export default function GenerateBox({ typeBox, tables }) {
  const [nextGenerated, setNextGenerated] = useState("");
  const [counter, setCounter] = useState(0);

  const handleClick = (e) => {
    e.preventDefault();
    setCounter(counter + 1);
    setNextGenerated(counter);

    //Here is where you will make a call to the backend for information
    //Pass it the tables to include, and other filters
  };

  return (
    <PageWrapper>
      <div>
        <form className="generate-form">
          <input readOnly={true} value={nextGenerated} className="textBox" />
          <button className="mainBtn" onClick={handleClick}>
            Generate!
          </button>
        </form>
      </div>
    </PageWrapper>
  );
}

const PageWrapper = styled.nav`
  display: flex;
  flex-direction: column;

  .generate-form {
    display: flex;
    flex-direction: column;
    margin-bottom: 3px;
  }
  .textBox {
    margin-bottom: 5px;
  }
`;
