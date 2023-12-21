import React, { useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { RootState } from "../store/configureStore";
import { loadProducts } from "../store/products";

interface Product {
  id: number;
  name: string;
  description: string;
  quantity: number;
  price: number;
}

const Inventory: React.FC = () => {
  const dispatch = useDispatch();
  const productList: Product[] = useSelector(
    (state: RootState) => state.entities.products.list
  );

  useEffect(() => {
    dispatch(loadProducts());
  }, [dispatch]);
  return (
    <div className="container mx-auto py-4">
      <div className="flex items-center justify-center">
        <div className="text-center">
          <h2 className="text-2xl font-bold mb-4 text-customBlue">
            Welcome to the Inventory Management System
          </h2>
          <p className="text-gray-600">
            This system helps you manage your inventory efficiently.
          </p>
        </div>
      </div>
      <section className="flex flex-wrap gap-6 justify-center">
        {productList.map((product) => (
          <div className="flex flex-col text-gray-700 bg-white shadow-md bg-clip-border rounded-xl w-full md:w-96">
            <div className="p-6">
              <h5 className="block mb-2 font-sans text-xl font-semibold leading-snug text-blue-gray-900">
                Name - {product.name}
              </h5>
              <h6 className="block text-base font-light leading-relaxed text-inherit">
                Description : {product.description}
              </h6>
              <h6 className="block text-base font-light leading-relaxed text-inherit">
                Quantity : {product.quantity}
              </h6>
            </div>
            <div className="p-6 pt-0">
              <button
                className="font-bold text-center uppercase transition-all disabled:opacity-50 disabled:shadow-none disabled:pointer-events-none text-xs py-3 px-6 rounded-lg bg-customGreen text-white shadow-md hover:shadow-lg focus:opacity-[0.85] focus:shadow-none active:opacity-[0.85] active:shadow-none"
                type="button"
              >
                Price: {product.price}
              </button>
            </div>
          </div>
        ))}
      </section>
    </div>
  );
};

export default Inventory;
