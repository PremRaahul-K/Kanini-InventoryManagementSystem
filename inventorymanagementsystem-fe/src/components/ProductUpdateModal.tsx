import React, { useState } from "react";
import { useDispatch } from "react-redux";
import { updateProductQuantity } from "../store/products";

interface ProductUpdateModalProps {
  productId: number;
  onClose: () => void;
}

const ProductUpdateModal: React.FC<ProductUpdateModalProps> = ({
  productId,
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
    <div className="modal-overlay">
      <div className="modal">
        <h2>Update Product</h2>
        <label>
          Quantity:
          <input
            type="number"
            value={updatedQuantity}
            onChange={(e) => setUpdatedQuantity(parseInt(e.target.value, 10))}
          />
        </label>
        <div>
          <button onClick={handleUpdate}>Update</button>
          <button onClick={onClose}>Cancel</button>
        </div>
      </div>
    </div>
  );
};

export default ProductUpdateModal;
