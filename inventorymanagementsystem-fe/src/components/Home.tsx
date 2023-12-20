import React from "react";
import { Link } from "react-router-dom";
import Inventory from "./Inventory";
import { Routes, Route } from "react-router-dom";
import ProductList from "./ProductList";
import AddProductForm from "./AddProductForm";

const Home: React.FC = () => {
  return (
    <div className="container mx-auto p-4 bg-gray-100">
      <header className="bg-gray-800 p-4 mb-8">
        <div className="flex items-center justify-between">
          <div>
            <Link to="/" className="text-white text-2xl font-bold">
              Inventory Management System
            </Link>
          </div>

          <nav>
            <ul className="flex space-x-4">
              <li>
                <Link to="/" className="text-white">
                  Inventory
                </Link>
              </li>
              <li>
                <Link to="/feedback" className="text-white">
                  Feedback
                </Link>
              </li>
              <li>
                <Link to="/orders" className="text-white">
                  Orders
                </Link>
              </li>
              {/* Add user profile/auth info here */}
            </ul>
          </nav>
        </div>
      </header>
      <Routes>
        <Route path={`/`} element={<Inventory />} />
        <Route path={`/product-list`} element={<ProductList />} />
        <Route path={`/add-product`} element={<AddProductForm />} />
      </Routes>
    </div>
  );
};

export default Home;
