import React, { Component } from "react";

export default class ProductList extends Component {
  render() {
    return (
      <div>
        <table className="table table-striped">
          <thead>
            <tr>
              <th scope="col">Id</th>
              <th scope="col">Pro Name</th>
              <th scope="col">Price</th>
              <th scope="col">Stock</th>
              <th scope="col">Cat Name</th>
              <th scope="col">Action</th>
            </tr>
          </thead>

          <tbody>
            {this.props.proProp.map((pro) => (
              <tr key={pro.id}>
                <th scope="row">{pro.id}</th>
                <td>{pro.name}</td>
                <td>{pro.price}</td>
                <td>{pro.stock}</td>
                <td>{pro.categoryId}</td>
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
