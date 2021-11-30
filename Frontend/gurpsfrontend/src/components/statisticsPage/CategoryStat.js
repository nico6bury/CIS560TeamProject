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
          <div>-Description: {item.description}</div>
          <div>-Owning User: {item.owningUser}</div>
          <div>-Average Cost Of An Item: {item.averageCost}</div>
          <div>-Average Weight Of An Item: {item.averageWeight}</div>
          <div>-Total Weight Of All Items: {item.totalWeight}</div>
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
    max-width: 400px;
    overflow-wrap: break-word;
  }
  .resultWrapper {
    display: flex;
    flex-direction: column;
  }
`;
