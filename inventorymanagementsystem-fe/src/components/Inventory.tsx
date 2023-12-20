import React from "react";
import { Link } from "react-router-dom";

const Inventory: React.FC = () => {
  return (
    <div>
      <ul className="flex space-x-4">
        <li>
          <Link to={`/product-list`} className="text-white">
            Product List
          </Link>
        </li>
        <li>
          <Link to={`/add-product`} className="text-white">
            Add Product
          </Link>
        </li>
      </ul>
    </div>
  );
};

export default Inventory;
