import axios from "axios";
import React, { Component } from "react";
import CategoryList from "./CategoryList";
import Navigation from "./Navigation";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import ProductList from "./ProductList";

export default class App extends Component {
  state = {
    categories: [],
    products: [],
    search: "",
  };
  async componentDidMount() {
    const resCat = await axios.get("https://localhost:7218/api/Category");
    const resPro = await axios.get("https://localhost:7218/api/Product");
    //console.log(response);
    this.setState({ categories: resCat.data });
    this.setState({ products: resPro.data });
    console.log(this.state.categories);
  }
  render() {
    return (
      <div>
        <div>
          <Navigation />
        </div>
        <Router>
          <div>
            <Routes>
              <Route path="/" element={<Home />} />
              <Route
                path="/category"
                element={<CategoryList catProp={this.state.categories} />}
              />
              <Route
                path="/product"
                element={<ProductList proProp={this.state.products} />}
              />
            </Routes>
          </div>
        </Router>
      </div>
    );
  }
}

function Home() {
  return <h2>Home</h2>;
}

/*
import axios from "axios";
import React, { Component } from "react";
import CategoryList from "./CategoryList";
import Navigation from "./Navigation";
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";

export default class App extends Component {
  state = {
    categories: [],
    search: "",
  };
  catList = () => {
    axios.get(`https://localhost:7131/api/Category`);
    const newCatList = this.state.categories;
    this.setState((state) => ({
      categories: newCatList,
    }));
    console.log(this.state.categories);
  };
  render() {
    return (
      <div>
        <div>
          <Navigation />
        </div>
        <Router>
          <div>
            <Routes>
              <Route path="/" element={<Home />} />
              <Route path="/category" element={<CategoryList />} />
              <Route path="/product" element={<ProductList />} />
            </Routes>
          </div>
        </Router>
      </div>
    );
  }
}

function ProductList() {
  return <h2>About</h2>;
}

function Home() {
  return <h2>Home</h2>;
}

*/
