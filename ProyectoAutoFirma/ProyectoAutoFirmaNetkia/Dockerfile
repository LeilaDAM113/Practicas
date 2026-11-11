# 1) Construir la web
FROM node:24-alpine AS construccion
WORKDIR /app
COPY package.json package-lock.json ./
RUN npm ci
COPY . .
RUN npm run build -- --output-path=dist/web
RUN find /app/dist -maxdepth 3 -type f

# 2) Servirla con nginx
FROM nginx:stable-alpine
COPY nginx.conf /etc/nginx/conf.d/default.conf
COPY --from=construccion /app/dist/web/browser /usr/share/nginx/html
EXPOSE 80