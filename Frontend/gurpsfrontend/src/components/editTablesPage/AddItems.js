import React, { useState, useEffect } from "react";
import styled from "styled-components";
import CreateTable from "./CreateTable";
import DisplayAndEditTables from "./DisplayAndEditTables";

let starterData = Object.freeze({
  name: "",
  unitPrice: "",
  baseWeight: "",
  weightType: "",
  quantityMin: "",
  quantityMax: "",
  description: "",
  relativeChance: "",
});

export default function AddItems({
  tables,
  isLoadedSuccessOrErrorMessage,
  setIsLoadedSuccessOrErrorMessage,
}) {
  const [tableData, setTableData] = useState("");
  const [addIsClicked, setAddIsClicked] = useState(false);
  const [newItemData, setNewItemData] = useState(starterData);
  const [goIsClicked, setGoIsClicked] = useState(false);
  const [tableValue, setTableValue] = useState("");
  const [addItemTableId, setAddItemTableId] = useState(-1);
  const [isLoaded, setIsLoaded] = useState("");

  useEffect(() => {
    setTableData(AddCheckedProperty(tables));
  }, []);

  const AddCheckedProperty = (tables) => {
    let finishedArray = [];
    tables.map((item) => {
      let curItem = {
        tableName: item.tableName,
        tableId: item.tableId,
        checked: false,
      };
      //console.log(curItem.name);
      finishedArray.push(curItem);
    });
    return finishedArray;
  };

  const handleNewItemClick = (e) => {
    e.preventDefault();
    setAddIsClicked(true);
    setIsLoadedSuccessOrErrorMessage("");
  };

  const getIdOfTable = () => {
    var radioButtons = document.getElementsByName("tableRadioOptions");
    for (var i = 0; i < radioButtons.length; i++) {
      if (radioButtons[i].checked == true) {
        setAddItemTableId(radioButtons[i].id);
      }
    }
  };

  const TablesCheckboxes = () => {
    // setState(s => ({ ...s, [target.name]:!s[target.name]}));
    console.log(tableData);
    let checkboxes = tableData.map((item, idx) => {
      let chkstr = "";
      console.log("ITEM: " + item.tableName + " " + item.tableId);
      return (
        <div className="checkboxes">
          <input
            type="radio"
            //onClick={(e) => handleToggle(e, idx)}
            //onChange={handleChange}
            key={item.tableId}
            id={item.tableId}
            name={"tableRadioOptions"}
            value={item.tableName}
            //checked={tableValue}
            //onChange={(e) => handleToggle(e, idx)}
            className="checkboxes"
            //readOnly={true}
          />
          <label className="checkboxes" for={item.tableId}>
            {item.tableName}
          </label>
        </div>
      );
    });
    return <div>{checkboxes}</div>;
  };

  const handleInputChange = (e) => {
    setNewItemData({
      ...newItemData,
      [e.target.name]: e.target.value,
    });
  };

  const handleNewItemAddClick = (e) => {
    e.preventDefault();
    //console.log(e.target);
    setGoIsClicked(false);
    getIdOfTable();
    doAddFetch();
  };

  const doAddFetch = () => {
    console.log(
      "CategoryId" +
        addItemTableId +
        "Name" +
        newItemData.name +
        "UnitPrice" +
        newItemData.unitPrice +
        "BaseWeight" +
        newItemData.baseWeight +
        "WeightType" +
        newItemData.weightType +
        "QuantityMin" +
        newItemData.quantityMin +
        "QuantityMax" +
        newItemData.quantityMax +
        "Description" +
        newItemData.description +
        "RelativeChance" +
        newItemData.relativeChance
    );
    let send = JSON.stringify({
      CategoryId: addItemTableId,
      Name: newItemData.name,
      UnitPrice: newItemData.unitPrice,
      BaseWeight: newItemData.baseWeight,
      WeightType: newItemData.weightType,
      QuantityMin: newItemData.quantityMin,
      QuantityMax: newItemData.quantityMax,
      Description: newItemData.description,
      RelativeChance: newItemData.relativeChance,
    });
    fetch(`http://localhost:5000/api/CreateItem/${send}`, {
      method: "get",
      headers: {
        //"Content-Type": "application/json",
        //"Access-Control-Allow-Credentials": true,
      },
      //credentials: "include",
    })
      .then((res) => res.json())
      .then(
        (result) => {
          console.log(result);
          setIsLoadedSuccessOrErrorMessage("successAddItem");
        },
        // Note: it's important to handle errors here
        // instead of a catch() block so that we don't swallow
        // exceptions from actual bugs in components.
        (error) => {
          setIsLoadedSuccessOrErrorMessage("error");
          //console.log(error);
        }
      );
  };

  const handleGoClick = (e) => {
    e.preventDefault();
    setGoIsClicked(true);
    setAddIsClicked(false);
    getIdOfTable();
  };

  return (
    <PageWrapper>
      <div>
        {!goIsClicked && (
          <button className="mainBtn" onClick={handleNewItemClick}>
            Add New Item
          </button>
        )}

        {addIsClicked && (
          <div>
            <div>Please select the table to add an item to.</div>
            <TablesCheckboxes />
            <button className="mainBtn" onClick={handleGoClick}>
              Go!
            </button>
          </div>
        )}
        {goIsClicked && (
          <div>
            <form className="addNewItemForm">
              <input
                className="formInput separaterBottom2"
                name="name"
                placeholder="Item Name"
                size="12"
                maxLength={20}
                onChange={handleInputChange}
              />
              <input
                className="formInput separaterBottom2"
                name="unitPrice"
                placeholder="Item Unit Price"
                size="12"
                maxLength={20}
                onChange={handleInputChange}
              />
              <input
                className="formInput separaterBottom2"
                name="baseWeight"
                placeholder="Item Base Weight"
                size="12"
                maxLength={20}
                onChange={handleInputChange}
              />
              <input
                className="formInput separaterBottom2"
                name="weightType"
                placeholder="Item Weight Type"
                size="12"
                maxLength={20}
                onChange={handleInputChange}
              />
              <input
                className="formInput separaterBottom2"
                name="quantityMin"
                placeholder="Item Quantity Min"
                size="12"
                maxLength={20}
                onChange={handleInputChange}
              />
              <input
                className="formInput separaterBottom2"
                name="quantityMax"
                placeholder="Item Quantity Max"
                size="12"
                maxLength={20}
                onChange={handleInputChange}
              />
              <input
                className="formInput separaterBottom2"
                name="description"
                placeholder="Item Description"
                size="20"
                maxLength={40}
                onChange={handleInputChange}
              />
              <input
                className="formInput separaterBottom2"
                name="relativeChance"
                placeholder="Item Relative Chance"
                size="20"
                maxLength={20}
                onChange={handleInputChange}
              />
              <button className="mainBtn" onClick={handleNewItemAddClick}>
                Add
              </button>
            </form>
          </div>
        )}
        {isLoadedSuccessOrErrorMessage === "errorAddItem" && (
          <div className="errorMessage">Error creating item.</div>
        )}
        {isLoadedSuccessOrErrorMessage === "successAddItem" && (
          <div className="successMessage">
            Successfully added item to table.
          </div>
        )}
      </div>
    </PageWrapper>
  );
}

const PageWrapper = styled.nav`
  .separaterBottom {
    margin-bottom: 20px;
  }
  .addNewItemForm {
    display: flex;
    flex-direction: column;
  }
  .separaterBottom2 {
    margin-bottom: 5px;
  }
`;
