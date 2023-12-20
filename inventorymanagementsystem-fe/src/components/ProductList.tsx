import React, { useState, useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { RootState } from "../store/configureStore";
import { loadProducts, deleteProduct } from "../store/products";
import ProductUpdateModal from "./ProductUpdateModal";

interface Product {
  id: number;
  name: string;
  description: string;
  quantity: number;
  price: number;
}

const ProductList: React.FC = () => {
  const dispatch = useDispatch();
  const productList: Product[] = useSelector(
    (state: RootState) => state.entities.products.list
  );

  useEffect(() => {
    dispatch(loadProducts());
  }, [dispatch]);

  const [selectedProductId, setSelectedProductId] = useState<number | null>(
    null
  );

  const handleDelete = (productId: number) => {
    dispatch(deleteProduct(productId));
  };

  const handleUpdate = (productId: number) => {
    setSelectedProductId(productId);
  };
  const handleCloseModal = () => {
    setSelectedProductId(null);
  };
  return (
    <div>
      <h2 className="text-2xl font-semibold mb-4">Product List</h2>
      <table className="min-w-full bg-white border border-gray-300">
        <thead>
          <tr>
            <th>ID</th>
            <th>Product Name</th>
            <th>Description</th>
            <th>Quantity</th>
            <th>Price</th>
            <th>Action</th>
          </tr>
        </thead>
        <tbody>
          {productList.map((product) => (
            <tr key={product.id}>
              <td>{product.id}</td>
              <td>{product.name}</td>
              <td>{product.description}</td>
              <td>{product.quantity}</td>
              <td>${product.price.toFixed(2)}</td>
              <td>
                <button onClick={() => handleDelete(product.id)}>Delete</button>
              </td>
              <td>
                <button onClick={() => handleUpdate(product.id)}>Update</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      {selectedProductId && (
        <ProductUpdateModal
          productId={selectedProductId}
          onClose={handleCloseModal}
        />
      )}
    </div>
  );
};

export default ProductList;
