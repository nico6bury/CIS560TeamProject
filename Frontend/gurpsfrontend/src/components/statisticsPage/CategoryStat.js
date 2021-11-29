import React, { useState, useEffect } from "react";
import styled from "styled-components";

export default function CategoryStat({ data }) {
  const Tables = () => {
    let toReturn = data.map((item) => {
      return (
        <div className="resultWrapper">
          <div>
            <b>{item.name}</b>
          </div>
          <div>{item.description}</div>
          <div>{item.owningUser}</div>
          <div>{item.averageCost}</div>
          <div>{item.averageWeight}</div>
          <div>{item.totalWeight}</div>
          <div className="separaterBottom" />
        </div>
      );
    });
    return <div>{toReturn}</div>;
  };

  return (
    <PageWrapper>
      <div className="displayWrapper">
        <Tables />
      </div>
    </PageWrapper>
  );
}

const PageWrapper = styled.nav`
  .displayWrapper {
    display: flex;
    flex-direction: row;
    border: 2px solid black;
    padding: 3px;
  }
  .resultWrapper {
    display: flex;
    flex-direction: column;
  }
`;
