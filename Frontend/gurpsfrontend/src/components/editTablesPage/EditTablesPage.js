import React, { useState, useEffect } from "react";
import styled from "styled-components";
import AddItems from "./AddItems";
import CreateTable from "./CreateTable";
import DisplayAndEditTables from "./DisplayAndEditTables";

let fakeUserData = [
  {
    table: "swords",
    creatingUser: "User1",
    id: 1,
    data: [
      {
        name: "wooden sword",
        id: 1,
        basePrice: "34.5",
        baseWeight: "20",
        weightType: "Pounds",
        quantityMin: "1",
        quantityMax: "5",
        description: "A sword made of wood. Not sharp.",
        relativeChance: "0.3",
      },
      {
        name: "metal sword",
        id: 2,
        basePrice: "100.4",
      },
    ],
  },
  {
    table: "animals",
    creatingUser: "User2",
    id: 2,
    data: [
      {
        name: "flamingo",
        id: 1,
        basePrice: "5.00",
      },
      {
        name: "tiger",
        id: 2,
        basePrice: "6.89",
      },
    ],
  },
];

export default function EditTablesPage({ userId }) {
  const [tableData, setTableData] = useState(fakeUserData);
  const [isLoadedSuccessOrErrorMessage, setIsLoadedSuccessOrErrorMessage] =
    useState("");

  return (
    <PageWrapper>
      <h3>Edit/Add Tables</h3>
      {/* <DisplayAndEditTables tableData={tableData} /> */}
      <div className="separaterBottom" />
      <CreateTable
        userId={userId}
        isLoadedSuccessOrErrorMessage={isLoadedSuccessOrErrorMessage}
        setIsLoadedSuccessOrErrorMessage={setIsLoadedSuccessOrErrorMessage}
      />
      <AddItems
        tables={tableData}
        isLoadedSuccessOrErrorMessage={isLoadedSuccessOrErrorMessage}
        setIsLoadedSuccessOrErrorMessage={setIsLoadedSuccessOrErrorMessage}
      />
    </PageWrapper>
  );
}

const PageWrapper = styled.nav`
  .separaterBottom {
    margin-bottom: 20px;
  }
`;
