import React, { useState, useEffect } from "react";
import styled from "styled-components";
import UserTable from ".././tableInfoPage/UserTable";

let starterData = {
  name: "",
  unitPrice: "",
  baseWeight: "",
  weightType: "",
  quantityMin: "",
  quantityMax: "",
  description: "",
  relativeChance: "",
};

export default function DisplayAndEditTables({ tableData }) {
  const [newItemData, setNewItemData] = useState(starterData);

  const Tables = () => {
    let toReturn = tableData.map((item) => {
      return (
        <div>
          <div>
            <b>{item.tableName}</b>
          </div>
          <UserTable data={item.data} />
          <div className="separaterBottom" />
        </div>
      );
    });
    return <div>{toReturn}</div>;
  };

  return (
    <PageWrapper>
      <div className="tableWrap">
        <Tables />
      </div>
    </PageWrapper>
  );
}

const PageWrapper = styled.nav`
  .separaterBottom {
    margin-bottom: 10px;
  }
  .tableWrap {
    display: flex;
    margin-right: 20px;
  }
`;
