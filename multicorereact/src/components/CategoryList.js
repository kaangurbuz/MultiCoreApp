import React, { Component } from "react";

export default class CategoryList extends Component {
  render() {
    return (
      <div>
        <table className="table table-striped">
          <thead>
            <tr>
              <th scope="col">Id</th>
              <th scope="col">Category Name</th>
              <th scope="col">Action</th>
            </tr>
          </thead>

          <tbody>
            {this.props.catProp.map((cat) => (
              <tr key={cat.id}>
                <th scope="row">{cat.id}</th>
                <td>{cat.name}</td>
                <td>
                  <button className="btn btn-primary btn-sm">E</button>
                  <button className="btn btn-warning btn-sm">U</button>
                  <button className="btn btn-danger btn-sm">D</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    );
  }
}

/*
import React, { Component } from "react";
import axios from "axios";

export default class CategoryList extends Component {
  stateCat = {
    categories: [],
  };
  async componentDidMount() {
    await axios.get("https://localhost:7218/api/Category").then((response) => {
      this.stateCat.categories = response.data;
    });

    console.log(this.stateCat.categories);
  }
  
  render() {
    return (
      <div>
        <table className="table table-striped">
          <thead>
            <tr>
              <th scope="col">Id</th>
              <th scope="col">Category Name</th>
              <th scope="col">Action</th>
            </tr>
          </thead>
          <tbody>
            {console.log(this.stateCat.categories)}

            {this.stateCat.categories.map((category) => (
              <tr>
                {console.log(category.id)}
                <th scope="row">{category.id}</th>
                <td>{category.name}</td>
                <td>
                  <button className="btn btn-primary">Edit</button>
                  <button className="btn btn-danger">Delete</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    );
    
  }
}

*/
