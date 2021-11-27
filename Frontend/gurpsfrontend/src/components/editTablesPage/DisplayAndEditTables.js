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

  const handleInputChange = (e) => {
    setNewItemData({
      ...newItemData,
      [e.target.name]: e.target.value,
    });
  };

  const handleNewItemAddClick = (e) => {
    e.preventDefault();
    console.log(e.target);
  };

  const Tables = () => {
    let toReturn = tableData.map((item) => {
      return (
        <div>
          <div>
            <b>{item.table}</b>
          </div>
          <UserTable data={item.data} />
          <div className="separaterBottom" />
          <form>
            <input
              className="formInput"
              name="itemNameInput"
              placeholder="Item Name"
              size="12"
              maxLength={20}
              onChange={handleInputChange}
            />
            <input
              className="formInput"
              name="unitPriceInput"
              placeholder="Item Unit Price"
              size="12"
              maxLength={20}
              onChange={handleInputChange}
            />
            <input
              className="formInput"
              name="baseWeightInput"
              placeholder="Item Base Weight"
              size="12"
              maxLength={20}
              onChange={handleInputChange}
            />
            <input
              className="formInput"
              name="weightTypeInput"
              placeholder="Item Weight Type"
              size="12"
              maxLength={20}
              onChange={handleInputChange}
            />
            <input
              className="formInput"
              name="quantityMinInput"
              placeholder="Item Quantity Min"
              size="12"
              maxLength={20}
              onChange={handleInputChange}
            />
            <input
              className="formInput"
              name="quantityMaxInput"
              placeholder="Item Quantity Max"
              size="12"
              maxLength={20}
              onChange={handleInputChange}
            />
            <input
              className="formInput"
              name="descriptionInput"
              placeholder="Item Description Name"
              size="20"
              maxLength={20}
              onChange={handleInputChange}
            />
            <input
              className="formInput"
              name="relativeChanceInput"
              placeholder="Item Relative Chance"
              size="12"
              maxLength={20}
              onChange={handleInputChange}
            />
            <button className="mainBtn" onClick={handleNewItemAddClick}>
              Add New Item
            </button>
          </form>
          <div className="separaterBottom" />
        </div>
      );
    });
    return <div>{toReturn}</div>;
  };

  return (
    <PageWrapper>
      <div>
        <Tables />
      </div>
    </PageWrapper>
  );
}

const PageWrapper = styled.nav`
  .separaterBottom {
    margin-bottom: 10px;
  }
`;
