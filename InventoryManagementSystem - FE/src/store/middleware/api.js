import axios from "axios";
import * as actions from "../api";
const api =
  ({ dispatch, getState }) =>
  (next) =>
  async (action) => {
    if (action.type !== actions.apiCallBegan.type) return next(action);
    const { url, method, data, onSuccess, onError, onStart, payload } =
      action.payload;
    if (onStart) dispatch({ type: onStart });
    next(action);
    try {
      const response = await axios.request({
        baseURL: "http://localhost:5024/api",
        url,
        method,
        data,
      });
      if (payload) {
        dispatch({
          type: onSuccess,
          payload: { ...response.data, ...payload },
        });
      } else {
        console.log(onSuccess);
        dispatch({
          type: onSuccess,
          payload: response.data,
        });
      }
    } catch (error) {
      console.log(error.message);
      dispatch({
        type: onError,
        payload: error.message,
      });
    }
  };

export default api;
