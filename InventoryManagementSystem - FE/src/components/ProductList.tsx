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

  const itemsPerPage = 10;
  const [currentPage, setCurrentPage] = useState(1);

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

  const indexOfLastItem = currentPage * itemsPerPage;
  const indexOfFirstItem = indexOfLastItem - itemsPerPage;
  const currentItems = productList.slice(indexOfFirstItem, indexOfLastItem);

  const paginate = (pageNumber: number) => {
    setCurrentPage(pageNumber);
  };

  return (
    <div className="container mx-auto py-4">
      <h2 className="text-2xl font-bold mb-4">Product List</h2>
      <table className="min-w-full bg-white border border-gray-300">
        <thead>
          <tr>
            <th className="py-2 px-4 border-b">ID</th>
            <th className="py-2 px-4 border-b">Product Name</th>
            <th className="py-2 px-4 border-b">Description</th>
            <th className="py-2 px-4 border-b">Quantity</th>
            <th className="py-2 px-4 border-b">Price</th>
            <th className="py-2 px-4 border-b">Delete</th>
            <th className="py-2 px-4 border-b">Update</th>
          </tr>
        </thead>
        <tbody>
          {currentItems.map((product) => (
            <tr key={product.id}>
              <td className="py-2 text-center border-b">{product.id}</td>
              <td className="py-2 text-center border-b">{product.name}</td>
              <td className="py-2 text-center px-4 border-b">
                {product.description}
              </td>
              <td className="py-2 text-center border-b">{product.quantity}</td>
              <td className="py-2 text-center border-b">
                ${product.price.toFixed(2)}
              </td>
              <td className="py-2 text-center border-b">
                <button
                  onClick={() => handleDelete(product.id)}
                  className="bg-red-500 hover:bg-red-700 text-white py-1 px-2 rounded"
                >
                  Delete
                </button>
              </td>
              <td className="py-2 text-center border-b">
                <button
                  onClick={() => handleUpdate(product.id)}
                  className="bg-blue-500 hover:bg-blue-700 text-white py-1 px-2 rounded"
                >
                  Update
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      <div className="mt-4 flex justify-center">
        <ul className="flex list-none">
          {Array(Math.ceil(productList.length / itemsPerPage))
            .fill(null)
            .map((_, index) => (
              <li
                key={index}
                className={`mx-1 ${
                  index + 1 === currentPage
                    ? "bg-blue-500 text-white"
                    : "bg-gray-200 hover:bg-gray-300 text-gray-700"
                } cursor-pointer px-3 py-2 rounded`}
                onClick={() => paginate(index + 1)}
              >
                {index + 1}
              </li>
            ))}
        </ul>
      </div>

      {selectedProductId && (
        <ProductUpdateModal
          productId={selectedProductId}
          productName={
            currentItems.find((item) => item.id === selectedProductId)?.name ||
            ""
          }
          onClose={handleCloseModal}
        />
      )}
    </div>
  );
};

export default ProductList;
