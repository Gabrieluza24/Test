# stage 1
FROM node:16.13.2-alpine AS my-app-build
WORKDIR /app
COPY . .
RUN npm ci && npm run build

# stage 2
FROM nginx:stable-alpine
COPY --from=my-app-build /app/dist/angular-test /usr/share/nginx/html
EXPOSE 80
