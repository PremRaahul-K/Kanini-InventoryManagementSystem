import React, { useState } from "react";
import { useDispatch } from "react-redux";
import { updateProductQuantity } from "../store/products";

interface ProductUpdateModalProps {
  productId: number;
  productName: string;
  onClose: () => void;
}

const ProductUpdateModal: React.FC<ProductUpdateModalProps> = ({
  productId,
  productName,
  onClose,
}) => {
  const dispatch = useDispatch();
  const [updatedQuantity, setUpdatedQuantity] = useState<number>(0);

  const handleUpdate = () => {
    // Dispatch action to update product
    dispatch(updateProductQuantity(productId, { quantity: updatedQuantity }));
    onClose(); // Close the modal after updating
  };

  return (
    <div
      className="relative z-10"
      aria-labelledby="modal-title"
      role="dialog"
      aria-modal="true"
    >
      <div className="fixed inset-0 bg-gray-500 bg-opacity-75 transition-opacity"></div>
      <div className="fixed inset-0 z-10 w-screen overflow-y-auto">
        <div className="flex min-h-full items-end justify-center p-4 text-center sm:items-center sm:p-0">
          <div className="relative transform overflow-hidden rounded-lg bg-white text-left shadow-xl transition-all sm:my-8 sm:w-full sm:max-w-lg">
            <div className="bg-white px-4 pb-4 pt-5 sm:p-6 sm:pb-4">
              <div className="sm:flex sm:items-start">
                <div className="mt-3 text-center sm:ml-4 sm:mt-0 sm:text-left">
                  <h3
                    className="text-base font-semibold leading-6 text-gray-900"
                    id="modal-title"
                  >
                    Update Product Quantity - {productName}
                  </h3>
                  <div className="mt-2">
                    <label className="text-sm text-gray-500">
                      Quantity: &nbsp;
                      <input
                        type="number"
                        min={0}
                        value={updatedQuantity}
                        onChange={(e) =>
                          setUpdatedQuantity(parseInt(e.target.value, 10))
                        }
                      />
                    </label>
                  </div>
                </div>
              </div>
            </div>
            <div className="bg-gray-50 px-4 py-3 sm:flex sm:flex-row-reverse sm:px-6">
              <button
                type="button"
                className="inline-flex w-full justify-center rounded-md bg-red-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-red-500 sm:ml-3 sm:w-auto"
                onClick={onClose}
              >
                Cancel
              </button>
              <button
                type="button"
                className="mt-3 inline-flex w-full justify-center rounded-md bg-yellow-300 px-3 py-2 text-sm font-semibold text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:bg-gray-50 sm:mt-0 sm:w-auto"
                onClick={handleUpdate}
              >
                Update
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ProductUpdateModal;
